import React , {useEffect,useReducer,useState} from 'react';
import { DataGrid } from '@material-ui/data-grid';
import { makeStyles } from '@material-ui/core/styles';
import PropTypes from 'prop-types';
import clsx from 'clsx';
import { initState, reducer,load } from '../../../actions/seller';

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
  { field: 'id', headerName: 'Id', flex: 1 },
  { field: 'firstName', headerName: 'FirstName', flex: 1 },
  { field: 'lastName', headerName: 'LastName', flex: 1 },
  {
    field: 'phoneNumber',
    headerName: 'Phone Number', 
    flex: 1
  },
  { field: 'email', headerName: 'Email', flex: 1 },
  { field: 'size', headerName: 'Size Of Farm', flex: 1},
  { field: 'harvestSize', headerName: 'Size Of Harvest', flex: 1},
  { field: 'harvestTime', headerName: 'Harvest Time', flex: 1},
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
     <DataGrid rows={state.sellers} columns={columns} pageSize={12} filterModel={{
          items: [
            { columnField: 'firstName', operatorValue: 'contains', value: '' },
          ],
        }}/>
  </div>
  );

}

List.propTypes = {
    className: PropTypes.string   
  };

export default List;