
import React , {useEffect,useContext,useState} from 'react';
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
import { userContext } from '../../../contexts/userProvider'
import { load } from '../../../actions/user'
import clsx from 'clsx';
import { Button } from '@material-ui/core';
import TextField from '@material-ui/core/TextField';
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogContent from '@material-ui/core/DialogContent';
import DialogTitle from '@material-ui/core/DialogTitle';
import Grid from '@material-ui/core/Grid';
import Checkbox from '@material-ui/core/Checkbox';
import FormControlLabel from '@material-ui/core/FormControlLabel';
import validate from 'validate.js';
import { deleteUser, create,update } from '../../../actions/user';
import Input from '@material-ui/core/Input';
import { Update } from '@material-ui/icons';

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
    row: {
      height: '42px',
      display: 'flex',
      alignItems: 'center',     
      margin : theme.spacing(1)
    },
    spacer: {
      flexGrow: 1
    },
    error :{
      color: '#ff0000',
      fontWeight : "bold"
    }
  }));

  const schema = {
    firstName: {
      presence: { allowEmpty: false, message: 'is required' }, 
      length: {
        maximum: 50
      }
    },
    lastName: {
      presence: { allowEmpty: false, message: 'is required' },
      length: {
        maximum: 50
      }
    },
    email: {
      presence: { allowEmpty: false, message: 'is required' },
      email :true,
      length: {
        maximum: 50
      }
    },
    phoneNumber: {
      presence: { allowEmpty: false, message: 'is required' },   
      length: {
        maximum: 50
      }
    }
  };
  
const List = props =>{
    const { className, ...rest } = props;
    const classes = useStyles();
    const {state, dispatcher}  = useContext(userContext);   
    const [open, setOpen] = useState(false);
   
    const [formState, setFormState] = useState({
      isValid: false,
      values: {},
      touched: {},
      errors: {}
    });
    
    useEffect(()=> {

      const errors = validate(formState.values, schema);
      setFormState(formState => ({
        ...formState,
        isValid: errors ? false : true,
        errors: errors || {}
      })); 

      var params = {
        dispatch : dispatcher
      }   

     load(params);
    },[formState.values]);

    const handleChange = event => {

      event.persist();
  
      setFormState(formState => ({
        ...formState,
        values: {
          ...formState.values,
          [event.target.name]:
            event.target.type === 'checkbox'
              ? event.target.checked
              : event.target.value
        },
        touched: {
          ...formState.touched,
          [event.target.name]: true
        }
      }));
    };

    const hasError = field =>
    {      
      return formState.touched[field] && formState.errors[field] ? true : false;
    }

    const handleClickOpen = () => {   

      const errors = validate(formState.values, schema);
      setFormState(formState => ({
        ...formState,
        isValid: errors ? false : true,
        errors: errors || {},
        values: {}  
      }));       

      setOpen(true);
    };
  
    const handleClose = () => {
      setOpen(false);
    };
   
    const handleDelete = id => {
      var params = {
        id : id,
        dispatch : dispatcher
      }  

      deleteUser(params)
    };

    const handleEdit = user => {     
    
      setFormState(formState => ({
        ...formState,        
        values: user       
      })); 

      setOpen(true);
    };

    const handleSubmit =event =>{

      event.preventDefault();

      let params = {
        email :formState.values.email,
        firstName :formState.values.firstName,
        lastName :formState.values.lastName,
        phoneNumber :formState.values.phoneNumber,
        active :formState.values.active,
        description : "",
        password : "Vx!1234567",
        imageUrl: "",
        userType: "BackOffice",
        dispatch : dispatcher,
        id:formState.values.id,
        setOpens :setOpen       
      }     
           
      try{

        if(params.id == undefined )
        {
          create(params); 
         
        }else {
          update(params);
        }
      
      }catch(error){
        console.log(error);
      }

    }

    return (
      <div {...rest}
      className={clsx(classes.root, className)}> 
      <div className={classes.row}> 
      <span className={classes.spacer} />
        <Button
          color="primary"
          variant="contained"
          onClick ={handleClickOpen}
        >
         Create
        </Button>
      </div>
      <div className={classes.root}>
      <Dialog open={open}  onClose={handleClose} aria-labelledby="form-dialog-title">
        <DialogTitle id="form-dialog-title">New User</DialogTitle>
        <form onSubmit={handleSubmit}>
        <DialogContent>                  
          <Grid
            container
            spacing={1}
          >
            <Grid
              item
              md={6}
              xs={12}
            >
               <TextField
                  className={classes.textField}
                  error={hasError('firstName')}             
                  fullWidth
                  helperText={
                    hasError('firstName') ? formState.errors.firstName[0] : null
                  }
                  label="First name"
                  name="firstName"
                  onChange={handleChange}
                  type="text"
                  value={formState.values.firstName || ''}
                  variant="outlined"
                />              
            </Grid>
            <Grid
              item
              md={6}
              xs={12}
            >
              <TextField
                  className={classes.textField}
                  error={hasError('lastName')}
                  helperText="Please specify the last name"
                  fullWidth
                  helperText={
                    hasError('lastName') ? formState.errors.lastName[0] : null
                  }
                  label="Last name"
                  name="lastName"
                  onChange={handleChange}
                  type="text"
                  value={formState.values.lastName || ''}
                  variant="outlined"
                />            
            </Grid>
            <Grid
              item
              md={6}
              xs={12}
            >
              <TextField
                  className={classes.textField}
                  error={hasError('email')}
                  helperText="Please specify the email"
                  margin="dense"
                  fullWidth
                  helperText={
                    hasError('email') ? formState.errors.email[0] : null
                  }
                  label="Email Address"
                  name="email"
                  onChange={handleChange}
                  type="text"
                  value={formState.values.email || ''}
                  variant="outlined"
                />                  
            </Grid>
            <Grid
              item
              md={6}
              xs={12}
            >
              <TextField
                  className={classes.textField}
                  error={hasError('phoneNumber')}
                  helperText="Please specify the phone number"
                  margin="dense"
                  fullWidth
                  helperText={
                    hasError('phoneNumber') ? formState.errors.phoneNumber[0] : null
                  }
                  label="Phone Number"
                  name="phoneNumber"
                  onChange={handleChange}
                  type="text"
                  value={formState.values.phoneNumber || ''}
                  variant="outlined"
                />    
              
            </Grid>
            <Grid
              item
              md={6}
              xs={12}
            >
              <FormControlLabel
                control={<Checkbox name="active" color="primary" checked={formState.values.active || false} onChange={handleChange} />}
                label="Active"
              />                 

            </Grid>
            <Grid
              item
              md={6}
              xs={12}
            >
              <Input type="hidden" value={formState.values.id}></Input>
            </Grid>
          </Grid>
        
        </DialogContent>
        <DialogActions>
          <Button onClick={handleClose} color="primary">
            Cancel
          </Button>
          <Button disabled={!formState.isValid}  type="submit" color="primary">
            Submit
          </Button>
        </DialogActions>
        </form>
      </Dialog>
      </div>
        <TableContainer component={Paper}>
          <Table className={classes.table} aria-label="simple table">
            <TableHead>
              <TableRow>
                <TableCell>FirstName</TableCell>
                <TableCell>LastName</TableCell>          
                <TableCell>Email</TableCell>    
                <TableCell>Phone Number</TableCell>    
                <TableCell>User Type</TableCell>       
                <TableCell align="center">Active</TableCell>
                <TableCell align="center">Actions</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {state.users.map((row) => (
                <TableRow key={row.id}>
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
                  <TableCell component="th" scope="row">
                    {row.userType}
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