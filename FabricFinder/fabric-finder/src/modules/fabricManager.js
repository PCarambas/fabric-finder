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



/*export const addFabric = (fabric) => {
    return getToken().then((token) => {
        return fetch(Url, {
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
};*/