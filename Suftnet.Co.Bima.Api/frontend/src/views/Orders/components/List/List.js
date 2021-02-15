
import React , {useEffect,useReducer,useState} from 'react';
import { DataGrid } from '@material-ui/data-grid';
import { makeStyles } from '@material-ui/core/styles';
import PropTypes from 'prop-types';
import clsx from 'clsx';
import { initState, reducer,load } from '../../../actions/order';

const useStyles = makeStyles((theme)=>({
  root: {
    backgroundColor: "#ffffff",
    height: '800px',
    width: '100%'   
  }
 
}));
   
const List = props =>
{
const { className, ...rest } = props;
const classes = useStyles();
const [state, dispatch]  = useReducer(reducer,initState);   

const columns = [
  { field: 'id', headerName: 'Order Id', flex: 1 },
  { field: 'orderDate', headerName: 'Order Date', flex: 1 },
  { field: 'itemName', headerName: 'Produce', flex: 1 },
  {
    field: 'quantity',
    headerName: 'Quantity',
    type: 'number',
    flex: 1
  },
  { field: 'unit', headerName: 'Unit', flex: 1 },
  { field: 'status', headerName: 'Status', flex: 1},
  { field: 'deliveryDate', headerName: 'Delivery Date', flex: 1},
];      

useEffect(()=> 
{      
    var params = {
      dispatch : dispatch
    }   

  load(params);
},[dispatch]);   

  return (
    <div {...rest}
    className={clsx(classes.root, className)}>            
     <DataGrid rows={state.orders} columns={columns} pageSize={12} filterModel={{
          items: [
            { columnField: 'orderDate', operatorValue: 'contains', value: '' },
          ],
        }}/>
  </div>
  );

}

List.propTypes = {
    className: PropTypes.string   
  };

export default List;