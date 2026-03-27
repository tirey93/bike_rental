import { useState } from 'react';
import axios from 'axios';

export function useDelete(url: string, id: number) {
  const [deleting, setDeleting] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const remove = async (onSuccess?: () => void) => {
    setDeleting(true);
    setError(null);
    try {
      await axios.delete(`${url}/${id}`);
      if (onSuccess) {
        onSuccess();
      };
    } catch (err) {
      setError(err instanceof Error ? err.message : 'Unknown error');
      throw err;
    } finally {
      setDeleting(false);
    }
  };

  return { remove, deleting, error } as const;
}

export function useDeleteWithBody<TBody = void>(url: string) {
  const [deleting, setDeleting] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const remove = async (body?: TBody, onSuccess?: () => void) => {
    setDeleting(true);
    setError(null);
    try {
      await axios.delete(`${url}`, { data: body });
      if (onSuccess) {
        onSuccess();
      };
    } catch (err) {
      setError(err instanceof Error ? err.message : 'Unknown error');
      throw err;
    } finally {
      setDeleting(false);
    }
  };

  return { remove, deleting, error } as const;
}

export function useDeleteWithBodyAndId<TBody = void>(url: string, id: number) {
  const [deleting, setDeleting] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const remove = async (body?: TBody, onSuccess?: () => void) => {
    setDeleting(true);
    setError(null);
    try {
      await axios.delete(`${url}/${id}`, { data: body });
      if (onSuccess) {
        onSuccess();
      };
    } catch (err) {
      setError(err instanceof Error ? err.message : 'Unknown error');
      throw err;
    } finally {
      setDeleting(false);
    }
  };

  return { remove, deleting, error } as const;
}