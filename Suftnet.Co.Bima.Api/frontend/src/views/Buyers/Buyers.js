import React from 'react';
import { makeStyles } from '@material-ui/styles';
import { List } from './components'

const useStyles = makeStyles(theme => ({
    root: {
      padding: theme.spacing(3)
    },
    content: {
      marginTop: theme.spacing(2)
    }
  }));

  const Buyers = () => {
    const classes = useStyles(); 
   
    return (
      <div className={classes.root}>     
        <div className={classes.content}>     
          <List />     
        </div>
      </div>
    );
  };

  export default Buyers;
  