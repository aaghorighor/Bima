import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import UserProvider from '../contexts/userProvider'
import { List } from './components'

const useStyles = makeStyles(theme => ({
    root: {
      padding: theme.spacing(3)
    },
    content: {
      marginTop: theme.spacing(2)
    }
  }));

  const Users = () => {
    const classes = useStyles(); 
   
    return (
      <div className={classes.root}>     
        <div className={classes.content}>     
        <UserProvider>
          <List />
        </UserProvider>       
        </div>
      </div>
    );
  };

  export default Users;
  