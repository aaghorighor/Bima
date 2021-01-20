import React from 'react';
import clsx from 'clsx';
import PropTypes from 'prop-types';
import { makeStyles } from '@material-ui/styles';
import { Card, CardContent, Grid, Typography, Avatar } from '@material-ui/core';
import PeopleIcon from '@material-ui/icons/PeopleOutlined';

const useStyles = makeStyles(theme => ({
  root: {   
    backgroundColor: '#008080',
    color: theme.palette.warning.contrastText
  },
  content: {
    alignItems: 'center',
    display: 'flex'
  },
  title: {
    fontWeight: 700
  },
  avatar: {
    backgroundColor: theme.palette.white,
    color: '#666666',
    height: 56,
    width: 56
  },
  icon: {
    height: 32,
    width: 32
  }
}));

const Users =props=>{

    const { className, ...rest } = props;

    const classes = useStyles();
  
    return (
      <Card
        {...rest}
        className={clsx(classes.root, className)}
      >
        <CardContent>
          <Grid
            container
            justify="space-between"
          >
            <Grid item>
              <Typography
                className={classes.title}
                color="inherit"
                gutterBottom
                variant="h3"
              >
                Users
              </Typography>
              <Typography
                color="inherit"
                variant="h3"
              >
              250
              </Typography>
            </Grid>
            <Grid item>
              <Avatar className={classes.avatar}>
                <PeopleIcon className={classes.icon} />
              </Avatar>
            </Grid>
          </Grid>
        </CardContent>
      </Card>
    );
  };

  Users.propTypes = {
    className: PropTypes.string
  };
  
  export default Users;