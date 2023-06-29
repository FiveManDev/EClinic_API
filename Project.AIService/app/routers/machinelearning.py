import sys
import os
data_path = os.path.join(os.path.dirname(__file__), '..', 'auth')
sys.path.append(data_path)
from fastapi import APIRouter, Depends, status, HTTPException, Response
from fastapi.responses import JSONResponse
from auth_bearer import JWTBearer,Role
from data.config import repository
from data.data import Model
from data.data import ModelDtos
router = APIRouter(tags=['MachineLearning'])

# @router.get('/test',dependencies=[Depends(JWTBearer(role = Role.Admin))] )
@router.get('/GetAllModel')
async def GetAllModel():
    try:
        data = repository.all()
        res = {
            "isSuccess": True,
            "data": data
        }
        return JSONResponse(res)
    except Exception as e:
        raise HTTPException(status_code=500, detail="Internal Server Error")
            
@router.post('/UploadModel')
def UploadModel(data:Model):
    result =repository.create(data)
    if result is False:
        res = {
            "isSuccess": False,
            "Message": "Create error"
        }
        return JSONResponse(res)
    res = {
            "isSuccess": True,
            "Message": "Create Success"
        }
    return JSONResponse(res)
@router.put('/UpdateModel')
def UpdateModel(data:ModelDtos):
    model = 
    result =repository.update(data.ModelID,data)
    if result is False:
        res = {
            "isSuccess": False,
            "Message": "Create error"
        }
        return JSONResponse(res)
    res = {
            "isSuccess": True,
            "Message": "Create Success"
        }
    return JSONResponse(res)
@router.delete('/DeleteModel')
def DeleteModel(id:str):
    result =repository.delete(id)
    if result is False:
        res = {
            "isSuccess": False,
            "Message": "Delete error"
        }
        return JSONResponse(res)
    res = {
            "isSuccess": True,
            "Message": "Delete Success"
        }
    return JSONResponse(res)
@router.put('/SelectModelPredict')
def SelectModelPredict():
    return "Khang"