
import React, { PropsWithChildren, useContext, useEffect, useState } from 'react';
import { ContentEnum } from './content.enum';

const ContentContext = React.createContext({} as ContentContextType);

interface ContentContextType {
  content: ContentEnum;
  change: (content: ContentEnum) => void;
}

export const ContentProvider = ({ children }: PropsWithChildren) => {
  const [content, setContent] = useState<ContentEnum>(ContentEnum.BIKES);

  const change = (content: ContentEnum) => {
    setContent(content);
  };

  return <ContentContext.Provider value={{ content: content, change }}>{children}</ContentContext.Provider>;
};

export const useContent = () => {
  const content = useContext(ContentContext);

  if (!content) {
    throw Error('useContent needs to be used inside ContentContext');
  }

  return content;
};