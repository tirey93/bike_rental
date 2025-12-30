import React, { PropsWithChildren, useContext, useState } from "react";

const ActionDrawerContext = React.createContext({} as ActionDrawerContextType);

export interface ActionDrawerContextType {
  open: boolean;
  openActionDrawer: () => void;
  closeActionDrawer: () => void;
}

export const ActionDrawerProvider = ({ children }: PropsWithChildren) => {
  const [open, setOpen] = useState<boolean>(false);

  const openActionDrawer = () => {
    setOpen(true);
  }

  const closeActionDrawer = () => {
    setOpen(false);
  }

  return <ActionDrawerContext.Provider value={{ open, openActionDrawer, closeActionDrawer }}>{children}</ActionDrawerContext.Provider>;
};

export const useActionDrawer = () => {
  const auth = useContext(ActionDrawerContext);

  if (!auth) {
    throw Error('useActionDrawer needs to be used inside ActionDrawerContext');
  }

  return auth;
};