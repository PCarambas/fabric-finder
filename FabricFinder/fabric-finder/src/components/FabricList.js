import { useEffect, useState } from "react";
import { getFabrics } from "../modules/fabricManager";
import Fabric from "./Fabric";


export default function FabricList({ }) {
    const [fabrics, setFabrics] = useState([]);

    const getAllFabrics = () => {
        getFabrics()
            .then(fabrics => {
                setFabrics(fabrics)
            });
    }
    useEffect(() => {
        getAllFabrics();
        console.log(fabrics);
    }, []);

    return (
        <>
            <h2>Fabric</h2>
            {fabrics?.map((fabric) =>

                < Fabric
                    key={fabric.id}
                    fabric={fabric}
                />
            )}
        </>
    );
}

