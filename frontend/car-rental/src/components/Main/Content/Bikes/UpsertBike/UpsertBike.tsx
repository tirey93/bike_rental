import { useActionDrawer } from "../../../ActionDrawer/ActionDrawerContext";

type Props = {
 edit: boolean
}
export const UpsertBike = ({edit}: Props) => {
  const { publishSuccess } = useActionDrawer();

  return ( 
    <div>
      {edit ? 'Edit Bike Form' : 'Add Bike Form'}
      <button onClick={publishSuccess}>Submit</button>
    </div>
  );
}