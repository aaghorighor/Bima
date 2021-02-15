
import React from 'react';
import clsx from 'clsx';
import PropTypes from 'prop-types';
import { makeStyles } from '@material-ui/core/styles';
import { Card, CardContent, Grid, Typography, Avatar } from '@material-ui/core';
import AccessAlarmsIcon from '@material-ui/icons/AccessAlarms';

const useStyles = makeStyles(theme => ({
    root: {
      backgroundColor:'#8f246b',
      color: theme.palette.white
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

const Bargains =props=>{

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
              Bargains
            </Typography>
            <Typography color="inherit" variant="h3">100</Typography>
          </Grid>
          <Grid item>
            <Avatar className={classes.avatar}>
              <AccessAlarmsIcon className={classes.icon} />
            </Avatar>
          </Grid>
        </Grid>        
      </CardContent>
    </Card>
  );
}

Bargains.propTypes = {
    className: PropTypes.string
  };

export default Bargains;