import { getToken } from "./authManager";

const apiUrl = "/api/Fabric";

export const getFabrics = () => {
    return getToken().then((token) => {
        return fetch(apiUrl, {
            method: "GET",
            headers: {
                Authorization: `Bearer ${token}`,
            },
        }).then((resp) => {
            if (resp.ok) {
                return resp.json();
            } else {
                throw new Error("An unknown error occurred while trying to get fabrics");
            }
        })


    });
};

export const getFabric = (id) => {
    return getToken().then((token) => {
        return fetch(`${apiUrl}/${id}`, {
            method: "GET",
            headers: {
                Authorization: `Bearer ${token}`,
            },
        }).then((res) => {
            if (res.ok) {
                return res.json();
            } else {
                throw new Error(
                    "An unknown error occurred while trying to get your fabric."
                );
            }
        });
    });
};

export const getFabricsByUserId = () => {
    return getToken().then((token) => {
        return fetch(`${apiUrl}/myFabrics`, {
            method: "GET",
            headers: {
                Authorization: `Bearer ${token}`,
            },
        }).then((resp) => {
            if (resp.ok) {
                return resp.json();
            } else {
                throw new Error("An unknown error occurred while trying to get fabrics");
            }
        })


    });
};



export const addFabric = (fabric) => {
    return getToken().then((token) => {
        return fetch(apiUrl, {
            method: "POST",
            headers: {
                Authorization: `Bearer ${token}`,
                "Content-Type": "application/json",
            },
            body: JSON.stringify(fabric),
        }).then((resp) => {
            if (resp.ok) {
                return resp.json();
            } else if (resp.status === 401) {
                throw new Error("Unauthorized");
            } else {
                throw new Error(
                    "An unknown error occurred while trying to save a new fabric.",
                );
            }
        });
    });
};

export const addPatternFabric = (patternFabric) => {
    return getToken().then((token) => {
        return fetch(`${apiUrl}/addpatternfabric`, {
            method: "POST",
            headers: {
                Authorization: `Bearer ${token}`,
                "Content-Type": "application/json",
            },
            body: JSON.stringify(patternFabric),
        }).then((resp) => {
            if (resp.ok) {
                return resp;
            } else if (resp.status === 401) {
                throw new Error("Unauthorized");
            } else {
                throw new Error(
                    "An unknown error occurred while trying to save a new patternFabric.",
                );
            }
        });
    });
};

export const updateFabric = (id, fabric) => {
    return getToken().then(token => {
        return fetch(`${apiUrl}/${id}`, {
            method: "PUT",
            headers: {
                Authorization: `Bearer ${token}`,
                "Content-Type": "application/json"
            },
            body: JSON.stringify(fabric)
        })
    })
};

export const deleteFabric = (id) => {
    return getToken().then((token) => {
        return fetch(`${apiUrl}/${id}`, {
            method: "Delete",
            headers: {
                Authorization: `Bearer ${token}`,
            }
        }).then((resp) => {
            if (!resp.ok) {
                throw new Error("Unknown error occurred while trying top delete fabric.");
            }
        });
    });
};