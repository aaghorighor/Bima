
import React from 'react';
import clsx from 'clsx';
import PropTypes from 'prop-types';
import { makeStyles } from '@material-ui/styles';
import { Card, CardContent, Grid, Typography, Avatar } from '@material-ui/core';
import ArrowUpwardIcon from '@material-ui/icons/ArrowUpward';
import LocalShippingIcon from '@material-ui/icons/LocalShipping';

const useStyles = makeStyles(theme => ({
    root: {
    
    },
    content: {
      alignItems: 'center',
      display: 'flex'
    },
    title: {
      fontWeight: 700
    },
    avatar: {
      backgroundColor: theme.palette.success.main,
      height: 56,
      width: 56
    },
    icon: {
      height: 32,
      width: 32
    },
    difference: {
      marginTop: theme.spacing(2),
      display: 'flex',
      alignItems: 'center'
    },
    differenceIcon: {
      color: theme.palette.success.dark
    },
    differenceValue: {
      color: theme.palette.success.dark,
      marginRight: theme.spacing(1)
    }
  }));

const Deliveries =props=>{

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
                color="textSecondary"
                gutterBottom
                variant="h3"
              >
               Deliveries
              </Typography>
              <Typography    color="textSecondary" variant="h3">10</Typography>
            </Grid>
            <Grid item>
              <Avatar className={classes.avatar}>
                <LocalShippingIcon className={classes.icon} />
              </Avatar>
            </Grid>
          </Grid>          
        </CardContent>
      </Card>
    );
  };

  Deliveries.propTypes = {
    className: PropTypes.string
  };
  
 export default Deliveries;