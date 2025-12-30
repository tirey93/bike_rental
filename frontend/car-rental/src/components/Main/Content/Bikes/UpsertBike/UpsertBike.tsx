
type Props = {
 edit: boolean
}
export const UpsertBike = ({edit}: Props) => {
  return ( 
    <div>
      {edit ? 'Edit Bike Form' : 'Add Bike Form'}
    </div>
  );
}