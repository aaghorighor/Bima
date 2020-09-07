import React, { useState, useReducer } from 'react';
import { makeStyles } from '@material-ui/styles';
import UserProvider from 'contexts/userProvider'
import { LoadUsers, Toolbar } from './components'

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
    <UserProvider>
      <div className={classes.root}>
          <Toolbar></Toolbar>
        <div className={classes.content}>
          <LoadUsers></LoadUsers>
        </div>
      </div>
    </UserProvider>
  );
};

export default Users;
