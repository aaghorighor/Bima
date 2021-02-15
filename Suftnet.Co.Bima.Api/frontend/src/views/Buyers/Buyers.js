import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import { List } from './components'
import Typography from '@material-ui/core/Typography';

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

  const Buyers = () => {
    const classes = useStyles(); 
   
    return (
      <div className={classes.root}>     
      <div className={classes.header}>       
        <Typography variant="h1" component="h2">
          Buyers
        </Typography>
        </div>
        <span className={classes.spacer} />
        <div className={classes.content}>     
          <List />     
        </div>
      </div>
    );
  };

  export default Buyers;
  