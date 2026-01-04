
import React, { PropsWithChildren, useContext, useEffect, useState } from 'react';
import { ContentEnum } from './content.enum';
import { useSearchParams } from 'react-router-dom';

const ContentContext = React.createContext({} as ContentContextType);

interface ContentContextType {
  content: ContentEnum;
  change: (content: ContentEnum) => void;
}

export const ContentProvider = ({ children }: PropsWithChildren) => {
  const [content, setContent] = useState<ContentEnum>(ContentEnum.BIKES);
  const [searchParams, setSearchParams] = useSearchParams();

  useEffect(() => {
    const param = searchParams.get('tab');
    const validValues = Object.values(ContentEnum);
    if (validValues.includes(param as ContentEnum)) {
      setContent(param as ContentEnum)
    }
  },[searchParams])

  const change = (content: ContentEnum) => {
    setContent(content);
    setSearchParams({ tab: content });
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