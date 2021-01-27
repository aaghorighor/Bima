import React , {useEffect,useReducer,useState} from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableContainer from '@material-ui/core/TableContainer';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Paper from '@material-ui/core/Paper';
import PropTypes from 'prop-types';
import Link from '@material-ui/core/Link';
import DeleteIcon from '@material-ui/icons/Delete';
import EditIcon from '@material-ui/icons/Edit';
import clsx from 'clsx';
import { initState, reducer,load } from '../../../actions/seller';
import Typography from '@material-ui/core/Typography';
import PlaylistAddSharpIcon from '@material-ui/icons/PlaylistAddSharp';

const useStyles = makeStyles((theme)=>({
    root: {
      '& > *': {
        margin: theme.spacing(1),
      },
    },
    table: {
      minWidth: 650,
    },
    link: {
      margin: theme.spacing(2)
    },
    action: {
      color: "#000000"
    },
    header: {
      height: '42px',
      display: 'flex',
      alignItems: 'center',     
      marginLeft : theme.spacing(2)
    },
    spacer: {
      flexGrow: 1
    }    
    
}));
   
const List = props =>{
const { className, ...rest } = props;
const classes = useStyles();
var [state,dispatch] = useReducer(reducer,initState);   
      
useEffect(()=> {      

    var params = {
      dispatcher : dispatch
    }       

  load(params);
},[]);   

const handleDelete=(id)=>
{

}
  
const handleEdit=(seller)=>
{

}

return (
      <div {...rest}
      className={clsx(classes.root, className)}> 
      <div className={classes.header}>      
        <Typography variant="h1" component="h2">
          Farmers
        </Typography>
        </div>
        <span className={classes.spacer} />
        <TableContainer component={Paper}>
          <Table className={classes.table} aria-label="simple table">
            <TableHead>
              <TableRow>
                <TableCell>CreatedAt</TableCell>              
                <TableCell>FirstName</TableCell>
                <TableCell>LastName</TableCell>          
                <TableCell>Email</TableCell>    
                <TableCell>Phone Number</TableCell>                
                <TableCell align="center">Active</TableCell>
                <TableCell align="center">Actions</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {state.sellers.map((row) => (
                <TableRow key={row.id}>
                  <TableCell component="th" scope="row">
                    {row.createdAt}
                  </TableCell>                  
                  <TableCell component="th" scope="row">
                    {row.firstName}
                  </TableCell>       
                  <TableCell component="th" scope="row">
                    {row.lastName}
                  </TableCell>        
                  <TableCell component="th" scope="row">
                    {row.email}
                  </TableCell>   
                  <TableCell component="th" scope="row">
                    {row.phoneNumber}
                  </TableCell>                   
                  <TableCell align="center">
                  {row.active == false ? "No" : "Yes"}
                  </TableCell>
                  <TableCell align="center">
                  <Link href="#" className= {classes.link,classes.action} onClick={handleEdit.bind(this, row)}>
                    <EditIcon />
                  </Link>
                  <Link className= {classes.link,classes.action} href="#" onClick={handleDelete.bind(this, row.id) }>
                    <DeleteIcon />
                  </Link>                     
                  <Link className= {classes.link,classes.action} href="#" >
                    <PlaylistAddSharpIcon />
                  </Link>                                
                  </TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </TableContainer>
      </div>    
  );
}

List.propTypes = {
    className: PropTypes.string   
  };

export default List;