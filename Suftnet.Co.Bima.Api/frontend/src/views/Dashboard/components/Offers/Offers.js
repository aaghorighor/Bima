import React from 'react';
import clsx from 'clsx';
import PropTypes from 'prop-types';
import { makeStyles } from '@material-ui/styles';
import { Card, CardContent, Grid, Typography, Avatar } from '@material-ui/core';
import AttachMoneyIcon from '@material-ui/icons/AttachMoney';

const useStyles = makeStyles(theme => ({
  root: {   
    backgroundColor:'#999966',
    color: theme.palette.primary.contrastText
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
    color: theme.palette.primary.main,
    height: 56,
    width: 56
  },
  icon: {
    height: 32,
    width: 32
  }
}));

const Offers =props=>{

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
                Offers
              </Typography>
              <Typography
                color="inherit"
                variant="h3"
              >
               20
              </Typography>
            </Grid>
            <Grid item>
              <Avatar className={classes.avatar}>
                <AttachMoneyIcon className={classes.icon} />
              </Avatar>
            </Grid>
          </Grid>
        </CardContent>
      </Card>
    );
  };

  Offers.propTypes = {
    className: PropTypes.string
  };
  
  export default Offers;