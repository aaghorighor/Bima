import React from 'react';
import clsx from 'clsx';
import PropTypes from 'prop-types';
import { makeStyles } from '@material-ui/core/styles';
import { AppBar, Toolbar,IconButton } from '@material-ui/core';
import Typography from '@material-ui/core/Typography';
import PublicRoundedIcon from '@material-ui/icons/PublicRounded';

const useStyles =  makeStyles(theme => ({
  root: {
    boxShadow: 'none'
  },
  title: {
    display: 'none',
    color: 'white',
    [theme.breakpoints.up('sm')]: {
      display: 'block'
    }
  },
  menuButton: {
    marginRight: theme.spacing(1),
  }
}));

const Topbar = props => {
  const { className, ...rest } = props;
  const classes = useStyles();

  return (
    <AppBar
      {...rest}
      className={clsx(classes.root, className)}
      color="primary"
      position="fixed"
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
          <Typography className={classes.title} variant="h6" noWrap>
          
        </Typography>
      </Toolbar>
    </AppBar>
  );
};

Topbar.propTypes = {
  className: PropTypes.string
};

export default Topbar;
