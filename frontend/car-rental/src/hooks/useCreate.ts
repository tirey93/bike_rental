import { useState } from 'react';
import axios from 'axios';

export function useCreate<TRequest, TResponse = any>(url: string) {
  const [saving, setSaving] = useState(false);
  const [error, setError] = useState<string | null>(null);
  const [response, setResponse] = useState<TResponse | null>(null);

  const create = async (payload: TRequest, onSuccess?: (res: TResponse) => void) => {
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

  return { create, saving, error, response } as const;
}
