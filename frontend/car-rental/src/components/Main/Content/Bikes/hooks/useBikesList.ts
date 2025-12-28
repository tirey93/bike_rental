import { useEffect, useState } from "react";
import { Bike } from "../dtos/Bike";
import axios from "axios";

export const useBikesList = () => {
    const [bikes, setBikes] = useState<Bike[]>([]);
    const [loading, setLoading] = useState<boolean>(true);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
      const fetchBikes = async () => {
        try {
          setLoading(true);
          const response = await axios.get<Bike[]>('http://localhost:5001/bike');
          
          console.log('Pobrane rowery:', response.data);
          console.log('Status:', response.status);
          
          setBikes(response.data);
        } catch (err) {
          let errorMessage = '';
          
          if (axios.isAxiosError(err)) {
            errorMessage = err.response?.data?.message || 
                          `Error ${err.response?.status}: ${err.message}`;
          } else if (err instanceof Error) {
            errorMessage = err.message;
          }
          
          setError(errorMessage);
        } finally {
          setLoading(false);
        }
      };

      fetchBikes();
    }, []);

    return { bikes, loading, error };
}