import React from 'react';
import { BsStar, BsStarFill, BsStarHalf} from 'react-icons/bs'

export default function Star({
    thresh,
    hoverValue,
    rating,
    handleHoverValue,
    handleSetRating, handleDoubleRating
}) {
    let isFilled = false;

    if (rating != null) {
        isFilled = rating >= thresh;
    } else {
        isFilled = hoverValue >= thresh;
    }
    if (isFilled) {
        if (thresh < rating || thresh < hoverValue) {
            return (
                <BsStarFill
                    color={"gold"}
                    size={25}
                    onClick={e => {

                        if (e.detail === 1) handleSetRating();
                        if (e.detail === 2) handleDoubleRating();
                    }}
                    
                    onMouseLeave={() => handleHoverValue(rating)}
                />
            );
        }
        else {
            return (
                <BsStarHalf
                    color={"gold"}
                    size={25}
                    onClick={e => {
                        if (e.detail === 1) handleSetRating();
                        if (e.detail === 2) handleDoubleRating();
                    }}
                    onMouseLeave={() => handleHoverValue(rating)}
                />
            );
        }
    } else {
        return (
            <BsStar
                color={"gold"}
                size={25}
                onMouseEnter={() => handleHoverValue(thresh)}
            />
        );
    }
}
