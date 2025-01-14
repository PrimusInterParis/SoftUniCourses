import * as request  from './requester';


const baseUrl = `http://localhost:3030/jsonstore/games`;


export const getAll = async () => {
    const result = await request.get(baseUrl);
    const games = Object.values(result);
    return games;
}

export const getOne = async (gameId) => {
    const result = await request.get(`${baseUrl}/${gameId}`);
    return result;
}

export const create = async (data) => {
    const result = await request.post(baseUrl,data);
    console.log(result);
    return result;
}

