import { useState } from 'react';
import axios from 'axios';

// Overload: no response expected
export function useUpdate<TRequest>(url: string, id: number): {
  update: (payload: TRequest, onSuccess?: () => void) => Promise<void>;
  updating: boolean;
  error: string | null;
};

// Overload: response of type TResponse
export function useUpdate<TRequest, TResponse = any>(url: string, id: number): {
  update: (payload: TRequest, onSuccess?: (res: TResponse) => void) => Promise<TResponse>;
  updating: boolean;
  error: string | null;
  response: TResponse | null;
};

// Implementation
export function useUpdate<TRequest, TResponse = any>(url: string, id: number) {
  const [updating, setUpdating] = useState(false);
  const [error, setError] = useState<string | null>(null);
  const [response, setResponse] = useState<TResponse | null>(null);

  const update = async (payload: TRequest, onSuccess?: (res: TResponse) => void) => {
    setUpdating(true);
    setError(null);
    try {
      const res = await axios.put<TResponse>(`${url}/${id}`, payload);
      setResponse(res.data);
      if (onSuccess) onSuccess(res.data);
      return res.data as any;
    } catch (err) {
      setError(err instanceof Error ? err.message : 'Unknown error');
      throw err;
    } finally {
      setUpdating(false);
    }
  };

  return { update, updating, error, response } as const;
}
