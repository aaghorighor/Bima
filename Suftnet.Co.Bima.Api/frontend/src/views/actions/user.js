import axios from 'axios';
import { createUrl, editUrl, deleteUrl,listUrl } from "../config/config"
import { actionType } from "../constants/constants"

const LOADING = "LOADING";
const ERROR = "ERROR";

export const initUserState = {
        users: [],   
        loading : false,
        message: ""
};

const loadingState =()=> {
    return {
        type: LOADING,
        loading: true
    };
};

const addState = (user) =>{
    return {
        type: ADD,
        user: user,
        message: "",       
        loading : false
    };
};

const editState = (user) =>{
    return {
        type: EDIT,
        user: user,
        message: "",       
        loading : false
    };
};

const listState = (users) =>{
    return {
        type: LIST,
        users: users,
        message: "",       
        loading : false
    };
};

const deleteState = (user) =>{
    return {
        type: DELETE,
        user: user,
        message: "",       
        loading : false
    };
};

const errorState = error=> {
    return {
        type: ERROR,
        users: null,
        message: error.message,      
        loading : false
    };
};

export const create =(params) => {
  
    params.dispatch(loadingState());
   
    axios.post(createUrl,params.user).then(json=>{
        params.dispatch(addState(json.data));      
    }).catch(error => {               
       params.dispatch(errorState(error.response.data));
    });
};

export const edit =(params) => {
  
    params.dispatch(loadingState());
   
    axios.post(editUrl,params.user).then(json=>{
        params.dispatch(editState(json.data));        
    }).catch(error => {               
       params.dispatch(errorState(error.response.data));
    });
};

export const remove =(params) => {
  
    params.dispatch(loadingState());
   
    axios.post(deleteUrl,params.user).then(json=>{
        params.dispatch(deleteState(json.data));        
    }).catch(error => {               
       params.dispatch(errorState(error.response.data));
    });
};

export const load =(params) => {
  
    params.dispatch(loadingState());
   
    axios.get(listUrl).then(json=>{
        params.dispatch(listState(json.data));  
    }).catch(error => {               
       params.dispatch(errorState(error.response.data));
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
            loading :action.loading
          };

      case actionType.EDIT :       

        return {

            ...state,
            users :state.map((user)=>{return user.id === action.user.id ? action.user:user}),            
            loading :action.loading
          };

      case actionType.DELETE :       

          return {
  
              ...state,
              users : state.users.filter((user)=> user.Id !== action.user.Id),                      
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
            loading : action.loading
          };     

       default :
       return state;
  }
};

