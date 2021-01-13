import React, { createContext, useReducer } from "react";
import { initAccountState, accountReducer} from "../actions/account"

export const identityContext = createContext();

export default function IdentityProvider ({ children }) {
  const [useState, dispatch] = useReducer(accountReducer, initAccountState);

  return (
    <identityContext.Provider
      value={{ state: useState, dispatcher: dispatch }}
    >
      {children}
    </identityContext.Provider>
  );
};


