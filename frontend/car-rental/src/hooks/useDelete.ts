import { useState } from 'react';
import axios from 'axios';

// Overload: no request body
export function useDelete(url: string, id: number): {
  remove: (onSuccess?: () => void) => Promise<void>;
  deleting: boolean;
  error: string | null;
};

// Overload: with request body of type TBody
export function useDelete<TBody>(url: string, id: number): {
  remove: (body: TBody, onSuccess?: () => void) => Promise<void>;
  deleting: boolean;
  error: string | null;
};

// Implementation
export function useDelete<TBody = void>(url: string, id: number) {
  const [deleting, setDeleting] = useState(false);
  const [error, setError] = useState<string | null>(null);

  // remove can be called as remove(onSuccess) or remove(body, onSuccess)
  const remove = async (bodyOrCallback?: TBody | (() => void), onSuccess?: () => void) => {
    let body: TBody | undefined;
    let callback: (() => void) | undefined = onSuccess;
    if (typeof bodyOrCallback === 'function') {
      callback = bodyOrCallback as () => void;
    } else {
      body = bodyOrCallback as TBody | undefined;
    }

    setDeleting(true);
    setError(null);
    try {
      if (body === undefined) {
        await axios.delete(`${url}/${id}`);
      } else {
        await axios.delete(`${url}/${id}`, { data: body });
      }
      if (callback) callback();
    } catch (err) {
      setError(err instanceof Error ? err.message : 'Unknown error');
      throw err;
    } finally {
      setDeleting(false);
    }
  };

  return { remove, deleting, error } as const;
}
