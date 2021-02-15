//export const host = "http://localhost:62137/api/";
export const host ="http://kcmkcm-001-site9.btempurl.com/api/"
//export const host = "http://localhost:62137/api/";

// login
export const loginUrl = host+ "account/login";
export const logoutUrl = host+ "account/logout";

// user
export const listUrl = host+"user/fetch";
export const createUrl = host+ "user/create";
export const updateUrl = host+ "user/update";
export const deleteUrl = host+ "user/delete";

export const sellerUrl = {
    fetch : host+"seller/fetch"
}

export const buyerUrl = {
    fetch : host+"buyer/fetch"
}

export const driverUrl = {
    fetch : host+"driver/fetch"
}

export const orderUrl = {
    fetch : host+"order/fetch"
}


