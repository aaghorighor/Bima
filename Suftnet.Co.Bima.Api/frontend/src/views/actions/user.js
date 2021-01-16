import axios from 'axios';
import { createUrl, updateUrl, deleteUrl,listUrl } from "../config/config"
import { actionType } from "../constants/constants"

const LOADING = "LOADING";
const ERROR = "ERROR";

export const initUserState = {
        users: [],   
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

const addState = (user) =>{
    return {
        type: actionType.ADD,
        user: user,
        message: "",       
        loading : false
    };
};

const updateState = (user) =>{
    return {
        type: actionType.EDIT,
        user: user,          
        loading : false
    };
};

const loadState = (users) =>{
    return {
        type: actionType.LIST,
        users: users,
        message: "",       
        loading : false
    };
};

const deleteState = (id) =>{
    return {
        type: actionType.DELETE,
        id: id,           
        loading : false
    };
};

const errorState = error=> {
    return {
        type: actionType.ERROR,
        users: null,
        message: error.message,      
        loading : false
    };
};

export const create =(params) => {
  
    params.dispatch(loadingState());   

    axios({ method: 'post', url: createUrl, data: params,
        config:  { headers: {  'Accept': 'application/json', 'Content-Type': 'application/json' }}
          }).then((json) => { 
              params.dispatch(addState(json.data));
              params.setOpens(false);   
             }) 
          .catch(error => { if (error.response && error.response.data) {
           //params.dispatch(errorState(error.response.data));
           console.log(error.response.data.message)
        }
    });   
    
};

export const update =(params) => {
  
    params.dispatch(loadingState());
     
    axios({ method: 'post', url: updateUrl, data:params ,
    config:  { headers: {  'Accept': 'application/json', 'Content-Type': 'application/json' }}
      }).then((json) => { 
          params.dispatch(updateState(params));    
          params.setOpens(false);     
        }) 
      .catch(error => { if (error.response && error.response.data) {
       //params.dispatch(errorState(error.response.data));
            console.log(error.response.data.message)
        }
    });   
};

export const deleteUser =(params) => {
  
    params.dispatch(loadingState());
   
    axios({ method: 'post', url: deleteUrl, data:params ,
    config:  { headers: {  'Accept': 'application/json', 'Content-Type': 'application/json' }}
      }).then((json) => { params.dispatch(deleteState(params.id)); }) 
      .catch(error => { if (error.response && error.response.data) {
       //params.dispatch(errorState(error.response.data));
            console.log(error.response.data.message)
        }
    });   
};

export const load =(params) => {
  
    params.dispatch(loadingState());
   
    axios.get(listUrl).then(json=>{
        params.dispatch(loadState(json.data));  
    }).catch(error => {               
        if (error.response && error.response.data) {
            params.dispatch(errorState(error.response.data));
        }
    });
};

export const userReducer = (state, action)=>
{
    state = state || initUserState;

  switch(action.type)
  {
      case actionType.ADD :       

        return {
            ...state,
            users :[...state.users, action.user],            
            loading :action.loading,
            close : true
          };

      case actionType.EDIT :       

        return {
            ...state,
            users :state.users.map((user)=>{return user.id === action.user.id ? action.user:user}),            
            loading :action.loading,
            close : true
          };

      case actionType.DELETE :     
           
          return {  
              ...state,
              users : state.users.filter((user)=> user.id !== action.id),                      
              loading :action.loading
            };

      case actionType.LIST :       

          return {  
              ...state,
              users :action.users,            
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

