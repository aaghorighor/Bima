import axios from 'axios';
import { driverUrl } from "../config/config"
import { actionType } from "../constants/constants"

const LOADING = "LOADING";
const ERROR = "ERROR";

export const initState = {
        drivers: [],   
        loading : false,
        message: "",
        close : false
};

const loadingState =()=> {
    return {
        type: LOADING,
        loading: true
    };
};

const loadState = (drivers) =>{
    drivers = drivers || [];
    return {
        type: actionType.LIST,
        drivers: drivers,
        message: "",       
        loading : false
    };
};

const errorState = error=> {
    return {
        type: actionType.ERROR,
        drivers: null,
        message: error.message,      
        loading : false
    };
};

export const load =(params) => {
  
    axios({ method: 'get', url: driverUrl.fetch, data:params ,
    config:  { headers: {  'Accept': 'application/json', 'Content-Type': 'application/json' }}
      }).then((json) => { params.dispatch(loadState(json.data)); }) 
      .catch(error => { if (error.response && error.response.data) {
       params.dispatch(errorState(error.response.data));
      }
          
    });   
};

export const reducer = (state, action)=>
{
    state = state || initState;

  switch(action.type)
  {     
      case actionType.LIST :       

          return {  
              ...state,
              drivers :action.drivers,            
              loading :action.loading
            };

      case LOADING :       
       
        return {
            ...state,           
            loading : action.loading
          };      

      case ERROR :       
       
        return {
            ...state,    
            message : action.message,
            loading : action.loading,
            close : action.close
          };     

       default :
       return state;
  }
};

