import React, { PropsWithChildren, ReactElement, useContext, useState } from "react";

const ActionDrawerContext = React.createContext({} as ActionDrawerContextType);
export type DrawerComponent<P = any> = React.ComponentType<P>;

export interface ActionDrawerContextType {
  open: boolean;
  node: ReactElement;
  openWith<P>(Comp: DrawerComponent<P>, props?: P): void;
  closeActionDrawer: () => void;
}

export const ActionDrawerProvider = ({ children }: PropsWithChildren) => {
  const [open, setOpen] = useState<boolean>(false);
  const [node, setNode] = useState<ReactElement>(<></>);

  const openWith = (Comp: DrawerComponent, props: any = null) => {
    setNode(<Comp {...props} />);
    setOpen(true);
  }

  const closeActionDrawer = () => {
    setOpen(false);
  }

  return <ActionDrawerContext.Provider value={{ open, node, openWith, closeActionDrawer }}>{children}</ActionDrawerContext.Provider>;
};

export const useActionDrawer = () => {
  const context = useContext(ActionDrawerContext);

  if (!context) {
    throw Error('useActionDrawer needs to be used inside ActionDrawerContext');
  }

  return context;
};