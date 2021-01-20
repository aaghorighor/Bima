import axios from 'axios';
import { sellerUrl } from "../config/config"
import { actionType } from "../constants/constants"

const LOADING = "LOADING";
const ERROR = "ERROR";

export const initState = {
        sellers: [],   
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

const loadState = (sellers) =>{
    return {
        type: actionType.LIST,
        sellers: sellers,
        message: "",       
        loading : false
    };
};

const errorState = error=> {
    return {
        type: actionType.ERROR,
        sellers: null,
        message: error.message,      
        loading : false
    };
};

export const load =(params) => {
  
    axios({ method: 'get', url: sellerUrl.fetch, data:params ,
    config:  { headers: {  'Accept': 'application/json', 'Content-Type': 'application/json' }}
      }).then((json) => { params.dispatcher(loadState(json.data)); }) 
      .catch(error => { if (error.response && error.response.data) {
       params.dispatcher(errorState(error.response.data));
      }          
    });   
};

export const reducer = (state, action)=>
{
    state = state || initState;

  switch(action.type)
  {     
      case actionType.LIST :       

      console.log(action.sellers);

          return {  
              ...state,
              sellers :action.sellers,            
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

