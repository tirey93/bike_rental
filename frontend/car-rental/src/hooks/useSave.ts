import { useState } from 'react';
import axios from 'axios';

// Overload: no response expected
export function useSave<TRequest>(url: string): {
  save: (payload: TRequest, onSuccess?: () => void) => Promise<void>;
  saving: boolean;
  error: string | null;
};

// Overload: response of type TResponse
export function useSave<TRequest, TResponse = any>(url: string): {
  save: (payload: TRequest, onSuccess?: (res: TResponse) => void) => Promise<TResponse>;
  saving: boolean;
  error: string | null;
  response: TResponse | null;
};

// Implementation
export function useSave<TRequest, TResponse = any>(url: string) {
  const [saving, setSaving] = useState(false);
  const [error, setError] = useState<string | null>(null);
  const [response, setResponse] = useState<TResponse | null>(null);

  const save = async (payload: TRequest, onSuccess?: (res: TResponse) => void) => {
    setSaving(true);
    setError(null);
    try {
      const res = await axios.post<TResponse>(url, payload);
      setResponse(res.data);
      if (onSuccess) onSuccess(res.data);
      return res.data as any;
    } catch (err) {
      setError(err instanceof Error ? err.message : 'Unknown error');
      throw err;
    } finally {
      setSaving(false);
    }
  };

  return { save, saving, error, response } as const;
}
