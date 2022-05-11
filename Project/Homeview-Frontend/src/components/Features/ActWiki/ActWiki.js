import {Form, Card, Modal} from 'react-bootstrap'
import React,{useState,useEffect} from 'react'
import Navigation from '../../Navigation'
import axios from 'axios';

//<script src='/Core/Security.js'></script>
const ActWiki = ({}) =>
{
        const API_KEY = '82da0caf88a6e84985e9fe3d753d6f43'
        const API_IMG = "https://image.tmdb.org/t/p/w500/"
        const [info, setInfo] = useState("");
        var actInfo = {};
        var moreActInfo = {Biography:'', birthday: '', place_of_birth: ''}
        return (
            <>
            <Navigation/>
            <div className = "container">    
                <div className = 'card-center'>
                    <Card>
                        <h2 className="text-center"> Actors / Actress </h2>
                        <input type='text' placeholder='Search...' value ={info} onChange={(e)=>
                                    setInfo(e.target.value)
                        }></input>
                        <button type='submit' placeholder='Search...' onClick={(e) =>
                        GetAct(info)
                        }>Submit</button>
                    </Card>
                </div>
            </div>
            
            </>
        )

        async function GetAct(actName)
        { 
            try
            {
                const res = fetch(`https://api.themoviedb.org/3/search/person?api_key=${API_KEY}&language=en-US&query=${actName}&page=1&include_adult=false`)
                const data = (await res).json()
                actInfo = data;
                data.then(jsonResponse=>{
                    actInfo = jsonResponse.results[0]
                    GetActInfo(actInfo.id)
                    console.log(actInfo.name)
                }).catch((err) => {
                    console.log('error from jsonResponse: ', err);
                })
            }
            catch(e)
            {
                console.log(e);
            }
        }

            async function GetActInfo(id)
            {

                try
                {
                    const moreInfo = fetch(`https://api.themoviedb.org/3/person/${actInfo.id}?api_key=${API_KEY}&language=en-US`)
                    const data = (await moreInfo).json()
                    data.then(jsonResponse=> {
                        moreActInfo.Biography = jsonResponse.biography
                        moreActInfo.birthday = jsonResponse.birthday
                        moreActInfo.place_of_birth = jsonResponse.place_of_birth
                        console.log(moreActInfo.Biography)
                        console.log(moreActInfo.birthday)
                        console.log(moreActInfo.place_of_birth)
                    }).catch((err) => {
                        console.log('error from jsonResponse: ', err);
                    })
                }
                catch(e)
                {
                    console.log(e)
                }   
            }


}
export default ActWiki



    