import React, { createContext, useReducer } from "react";
import { initUserState, userReducer} from "../actions/user"

export const userContext = createContext();

export default function UserProvider ({ children }) {
  const [userState, dispatch] = useReducer(userReducer, initUserState);

  return (
    <userContext.Provider
      value={{ state: userState, dispatcher: dispatch }}
    >
      {children}
    </userContext.Provider>
  );
};


