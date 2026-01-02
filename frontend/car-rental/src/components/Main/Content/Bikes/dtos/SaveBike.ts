
export interface SaveBike {
  model: string;
  color: string;
  lastServiceDate: string;
}

export const formatDateOnly = (date?: Date) => {
  let d = date;
  if (!d) 
    d = new Date();
  return `${d.getFullYear()}-${String(d.getMonth()+1).padStart(2,'0')}-${String(d.getDate()).padStart(2,'0')}`;
};