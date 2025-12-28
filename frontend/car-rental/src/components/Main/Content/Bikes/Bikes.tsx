import { useBikesList } from "./hooks/useBikesList";

export const Bikes = () => {
  const { bikes, loading, error } = useBikesList();

  return ( 
    <div>
      Bikes Component
    </div>
  );
}