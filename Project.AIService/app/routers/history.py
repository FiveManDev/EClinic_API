import sys
import os
data_path = os.path.join(os.path.dirname(__file__), '..', 'auth')
sys.path.append(data_path)
from fastapi import APIRouter, Depends, status, HTTPException, Response
from fastapi.responses import JSONResponse
from auth_bearer import JWTBearer,Role
import data.historyRepository as repository
from data.data import  DeepLearning
router = APIRouter(tags=['History'])

# # @router.get('/test',dependencies=[Depends(JWTBearer(role = Role.Admin))] )
@router.get('/History/GetAll')
async def GetAll():
    try:
        data = repository.GetAll()
        res = {
            "isSuccess": True,
            "data": data
        }
        return JSONResponse(res)
    except Exception as e:
        raise HTTPException(status_code=500, detail="Internal Server Error")
@router.get('/History/GetByID')
async def GetByID(id:str):
    try:
        data = repository.GetByID(id)
        res = {
            "isSuccess": True,
            "data": data
        }
        return JSONResponse(res)
    except Exception as e:
        raise HTTPException(status_code=500, detail="Internal Server Error")          