import React from 'views/UserList/components/Toolbar/node_modules/react';
import PropTypes from 'views/UserList/components/Toolbar/node_modules/prop-types';
import clsx from 'views/UserList/components/Toolbar/node_modules/clsx';
import { makeStyles } from 'views/UserList/components/Toolbar/node_modules/@material-ui/styles';
import { Button } from 'views/UserList/components/Toolbar/node_modules/@material-ui/core';

const useStyles = makeStyles(theme => ({
  root: {},
  row: {
    height: '42px',
    display: 'flex',
    alignItems: 'center',
    marginTop: theme.spacing(1)
  },
  spacer: {
    flexGrow: 1
  },
  importButton: {
    marginRight: theme.spacing(1)
  },
  exportButton: {
    marginRight: theme.spacing(1)
  },
  searchInput: {
    marginRight: theme.spacing(1)
  }
}));

const Toolbar = props => {
  const { className, ...rest } = props;

  const classes = useStyles();

  return (
    <div
      {...rest}
      className={clsx(classes.root, className)}
    >
      <div className={classes.row}>
        <span className={classes.spacer} />
        <Button className={classes.importButton}>Import</Button>
        <Button className={classes.exportButton}>Export</Button>
        <Button
          color="primary"
          variant="contained"
        >
          Add user
        </Button>
      </div>
      <div className={classes.row}>
        
      </div>
    </div>
  );
};

Toolbar.propTypes = {
  className: PropTypes.string
};

export default Toolbar;
