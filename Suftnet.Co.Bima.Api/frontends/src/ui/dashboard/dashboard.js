import React from 'react';
import { makeStyles } from '@material-ui/styles';
import { Grid } from '@material-ui/core';
// import { OpenStatus, Latest, InProgress, CloseStatus } from './components'

const useStyles = makeStyles(theme => ({
    root: {
      padding: theme.spacing(4)
    }
  }));

  const Dashboard = () => {
    const classes = useStyles();

    return (
        <div className = {classes.root}>
            <Grid 
             spacing = {4}
             container>
                 <Grid
                  item
                  lg={4}
                  sm={12}
                  xl={4}
                  xs={12}
                 >
               
                </Grid>
                 <Grid
                  item
                  lg={4}
                  sm={12}
                  xl={4}
                  xs={12}
                 >
             
                 </Grid>
                 <Grid
                  item
                  lg={4}
                  sm={12}
                  xl={4}
                  xs={12}
                 >
                
                 </Grid>

                 <Grid
                  item
                  lg={12}
                  md={12}
                  xl={12}
                  xs={12}
                 >
              
                 </Grid>

            </Grid>

        </div>
    );

  };

   export default Dashboard;