import { on } from "events";
import React, { PropsWithChildren, ReactElement, useContext, useState } from "react";

const ActionDrawerContext = React.createContext({} as ActionDrawerContextType);
export type DrawerComponent<P = any> = React.ComponentType<P>;

interface OpenWithOptions<P> {
  component: DrawerComponent<P>;
  props?: P;
  onSuccess?: () => void;
}
export interface ActionDrawerContextType {
  open: boolean;
  node: ReactElement;
  openWith<P>(options: OpenWithOptions<P>): void;
  publishSuccess: () => void;
  closeActionDrawer: () => void;
}

export const ActionDrawerProvider = ({ children }: PropsWithChildren) => {
  const [open, setOpen] = useState<boolean>(false);
  const [node, setNode] = useState<ReactElement>(<></>);
  const [onSuccess, setOnSuccess] = useState<(() => void) | null>(null);

  const openWith = (options: OpenWithOptions<any>) => {
    setNode(<options.component {...options.props} />);
    setOnSuccess(() => options.onSuccess || null);
    setOpen(true);
  }

  const closeActionDrawer = () => {
    setOpen(false);
  }

  const publishSuccess = () => {
    closeActionDrawer();
    onSuccess && onSuccess();
  }

  return <ActionDrawerContext.Provider value={{ open, node, openWith, closeActionDrawer, publishSuccess }}>{children}</ActionDrawerContext.Provider>;
};

export const useActionDrawer = () => {
  const context = useContext(ActionDrawerContext);

  if (!context) {
    throw Error('useActionDrawer needs to be used inside ActionDrawerContext');
  }

  return context;
};