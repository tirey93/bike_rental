import React, { PropsWithChildren, useContext, useState } from "react";
import { ActionDrawerMode } from "./enums/ActionDrawerMode";

const ActionDrawerContext = React.createContext({} as ActionDrawerContextType);

export interface ActionDrawerContextType {
  open: boolean;
  mode: ActionDrawerMode;
  openActionDrawer: (mode: ActionDrawerMode) => void;
  closeActionDrawer: () => void;
}

export const ActionDrawerProvider = ({ children }: PropsWithChildren) => {
  const [open, setOpen] = useState<boolean>(false);
  const [mode, setMode] = useState<ActionDrawerMode>(ActionDrawerMode.NONE);

  const openActionDrawer = (mode: ActionDrawerMode) => {
    setMode(mode);
    setOpen(true);
  }

  const closeActionDrawer = () => {
    setOpen(false);
  }

  return <ActionDrawerContext.Provider value={{ open, mode, openActionDrawer, closeActionDrawer }}>{children}</ActionDrawerContext.Provider>;
};

export const useActionDrawer = () => {
  const context = useContext(ActionDrawerContext);

  if (!context) {
    throw Error('useActionDrawer needs to be used inside ActionDrawerContext');
  }

  return context;
};