import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Typography from '@material-ui/core/Typography';
import { List } from './components'

const useStyles = makeStyles(theme => ({
    root: {
      padding: theme.spacing(3)
    },
    content: {
      marginTop: theme.spacing(2)
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

  const Drivers = () => {
    const classes = useStyles(); 
   
    return (
      <div className={classes.root}>     
      <div className={classes.header}>       
        <Typography variant="h1" component="h2">
          Logistics
        </Typography>
        </div>
        <span className={classes.spacer} />
        <div className={classes.content}>     
        <List />     
        </div>
      </div>
    );
  };

  export default Drivers;
  