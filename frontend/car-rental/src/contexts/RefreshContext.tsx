import { createContext, useCallback, useContext, useState } from "react";
import { ContentEnum } from "../components/Main/Content/content.enum";

interface RefreshContextType {
  refreshKeys: Record<ContentEnum, number>;
  triggerRefresh: (key: ContentEnum) => void;
}

const RefreshContext = createContext({} as RefreshContextType);

export const RefreshProvider = ({ children }: { children: React.ReactNode }) => {
  const [refreshKeys, setRefreshKeys] = useState<Record<ContentEnum, number>>({Bikes: 0, Stations: 0});

  const triggerRefresh = useCallback((key: ContentEnum) => {
    setRefreshKeys(prev => ({
      ...prev,
      [key]: prev[key] + 1
    }));
  }, []);

  return (
    <RefreshContext.Provider value={{ refreshKeys, triggerRefresh }}>
      {children}
    </RefreshContext.Provider>
  );
};

export const useRefresh = () => {
  const context = useContext(RefreshContext);
  if (!context) throw new Error('useRefresh must be used within RefreshProvider');
  return context;
};