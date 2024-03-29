import axios from 'axios';
import { loginUrl } from "../config/config"
import { userTypes } from "../constants/constants"

const LOGOUT = "LOGOUT";
export const RESPONSE = "RESPONSE";
const INPROGRESS = "INPROGRESS";

export const initAccountState = {
    user: null,
        message: "",
        status: false,
        inProgress : false
};

const inProgressState =()=> {
    return {
        type: INPROGRESS,
        inProgress: true
    };
};

const successState = (response) =>{
    return {
        type: RESPONSE,
        user: response,
        message: "",
        status: true,
        inProgress : false
    };
};

const failStates = error=> {
    return {
        type: RESPONSE,
        user: null,
        message: error.message,
        status: false,
        inProgress : false
    };
};

export function logoutState() {
    return {
        type: LOGOUT,
        user: null,
        message: null,
        status: false,
        inProgress : false
    };
};

export const login =(params) => {
  
    params.dispatch(inProgressState());
   
    axios.post(loginUrl,{ "userName" : params.email, "password" : params.password,
    config:  { headers: {  'Accept': 'application/json', 'Content-Type': 'application/json', "Access-Control-Allow-Origin" : "*" }}
        }).then(json=>{        
        params.dispatch(successState(json.data));
        navigateTo(json.data,params.history);         
      
    }).catch(error => {    
        
        if (error.response && error.response.data) {
            params.dispatch(failStates(error.response.data));
        }
     
    });
};

export const logout =(params)=>{
    params.dispatch(logoutState());  
    params.history.push("/sign-in")
}

export const accountReducer = (state, action)=>
{
    state = state || initAccountState;

  switch(action.type)
  {
      case RESPONSE :       

        return {

            ...state,
            user :action.user,
            message : action.message,
            status : action.status,
            inProgress :action.inProgress
          };

      case INPROGRESS :       
       
        return {

            ...state,           
            inProgress : action.inProgress
          };

      case LOGOUT :
        return {  
              ...state,
              user :action.user,
              message : action.message,
              status : action.status,
              inProgress :action.inProgress
            };

       default :
       return state;
  }
};

const navigateTo = (response, history)=>
{
    console.log(response);

    const { userType } = response;
   
    switch(userType)
    {
      case userTypes.BACK_OFFICE :      
   
          history.push("/orders")
          break;
      case userTypes.CUSTOMER_OFFICE :
          break;
      case userTypes.DRIVER_OFFICE :
          break;
      default :
          break;
    }
}