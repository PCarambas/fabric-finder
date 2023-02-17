import { useEffect, useState } from "react";
import { getPatternsByUserId } from "../modules/fabricManager";
import Pattern from "./Pattern";


export default function PatternList({ }) {
    const [patterns, setPatterns] = useState([]);

    const getAllPatterns = () => {
        getPatternsByUserId()
            .then(patterns => {
                setpatterns(patterns)
            });
    }
    useEffect(() => {
        getAllPatterns();
    }, []);

    return (
        <>
            <h2>Patterns</h2>
            {patterns?.map((pattern) =>

                < Pattern
                    key={pattern.id}
                    pattern={pattern}
                    getAllPatterns={getAllPatterns}
                />
            )}
        </>
    );
}