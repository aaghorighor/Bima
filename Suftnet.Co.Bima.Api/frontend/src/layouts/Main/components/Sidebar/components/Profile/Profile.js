import React, {useContext} from 'react';
import { Link as RouterLink } from 'react-router-dom';
import clsx from 'clsx';
import PropTypes from 'prop-types';
import { makeStyles } from '@material-ui/core/styles';
import { Avatar, Typography } from '@material-ui/core';
import { identityContext } from '../../../../../../views/contexts/indentityProvider'

const useStyles = makeStyles(theme => ({
  root: {
    display: 'flex',
    flexDirection: 'column',
    alignItems: 'center',
    minHeight: 'fit-content'
  },
  avatar: {
    width: 60,
    height: 60
  },
  name: {
    marginTop: theme.spacing(1)
  }
}));

const Profile = props => {
  const { className, ...rest } = props;

  const classes = useStyles();
  const {state}  = useContext(identityContext);   
  
  const user = {
    name: state.user == null ? "" : state.user.userName,
    avatar: '/images/avatars/avatar_11.png',
    bio: ''
  };

  return (
    <div
      {...rest}
      className={clsx(classes.root, className)}
    >
      <Avatar
        alt="Person"
        className={classes.avatar}
        component={RouterLink}
        src={user.avatar}
        to="/settings"
      />
      <Typography
        className={classes.name}
        variant="h5"
        
      >
        {user.name}
      </Typography>     
    </div>
  );
};

Profile.propTypes = {
  className: PropTypes.string
};

export default Profile;
