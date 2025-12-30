
type Props = {
 edit: boolean
}
export const UpsertStation = ({edit}: Props) => {
  return ( 
    <div>
      {edit ? 'Edit Station Form' : 'Add Station Form'}
    </div>
  );
}