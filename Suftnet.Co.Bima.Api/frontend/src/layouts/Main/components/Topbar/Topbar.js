import React, { useContext } from 'react';
import { useHistory } from 'react-router-dom';
import clsx from 'clsx';
import PropTypes from 'prop-types';
import { makeStyles } from '@material-ui/styles';
import { AppBar, Toolbar, IconButton } from '@material-ui/core';
import InputIcon from '@material-ui/icons/Input';
import AccountCircle from '@material-ui/icons/AccountCircle';
import { logout } from '../../../../views/actions/account'
import { identityContext } from '../../../../views/contexts/indentityProvider'
import Typography from '@material-ui/core/Typography';
import PublicRoundedIcon from '@material-ui/icons/PublicRounded';

const useStyles = makeStyles(theme => ({
  root: {
    
  },
  flexGrow: {
    flexGrow: 1
  },
  signOutButton: {
    marginLeft: theme.spacing(1)
  },
  title: {
    display: 'none',
    color: 'white',
    [theme.breakpoints.up('sm')]: {
      display: 'block',
    },
  },
  menuButton: {
    marginRight: theme.spacing(1),
  }
}));

const Topbar = props => {
  const { className, ...rest } = props;
  const classes = useStyles();

  const {dispatcher}  = useContext(identityContext);   
  let history = useHistory();

  const handleSignOut=()=>{      

    let params = {    
      dispatch : dispatcher,
      history : history
    }

    try{
      logout(params);         

    }catch(error){
      console.log(error);
    }
  };

  return (
    <AppBar
      {...rest}
      className={clsx(classes.root, className)}
    >
      <Toolbar>
          <IconButton
            edge="start"
            className={classes.menuButton}
            color="inherit"
            aria-label="open drawer"
          >
            <PublicRoundedIcon />
          </IconButton>
          <Typography className={classes.title} variant="h3" noWrap>
            Farm Hub
        </Typography>
        <div className={classes.flexGrow} />
        <IconButton color="inherit">      
          </IconButton>
          <IconButton
            className={classes.signOutButton}
            color="inherit"
            onClick={handleSignOut}          
            >
            <InputIcon />
          </IconButton>
        
      </Toolbar>
    </AppBar>
  );
};

Topbar.propTypes = {
  className: PropTypes.string 
};

export default Topbar;
