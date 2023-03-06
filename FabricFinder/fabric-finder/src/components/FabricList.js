import { useEffect, useState } from "react";
import { getFabrics, getFabricsByUserId } from "../modules/fabricManager";
import Fabric from "./Fabric";


export default function FabricList({ }) {
    const [fabrics, setFabrics] = useState([]);

    const getAllFabrics = () => {
        getFabricsByUserId()
            .then(fabrics => {
                setFabrics(fabrics)
            });
    }
    useEffect(() => {
        getAllFabrics();
    }, []);

    return (
        <>
            <br></br><h1>Fabric Finder</h1><br></br>
            {fabrics?.map((fabric) =>

                < Fabric
                    key={fabric.id}
                    fabric={fabric}
                    getAllFabrics={getAllFabrics}
                />
            )}
        </>
    );
}

