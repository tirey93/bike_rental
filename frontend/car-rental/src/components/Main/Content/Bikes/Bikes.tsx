import { bikeApiUrl } from "../../../../consts";
import { useFetch } from "../../../../hooks/useFetch";
import { Bike } from "./dtos/Bike";

export const Bikes = () => {
  const { data, loading, error } = useFetch<Bike[]>(bikeApiUrl);

  return ( 
    <div>
      Bikes Component
    </div>
  );
}