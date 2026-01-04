
export interface Bike {
  id: number;
  externalId: string;
  model: string;
  color: string;
  lastServiceDate: Date;
  stationCode?: string;
  stationExternalId?: string;
}