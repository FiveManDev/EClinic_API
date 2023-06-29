import sys
import os
data_path = os.path.join(os.path.dirname(__file__), '..', 'auth')
sys.path.append(data_path)
from fastapi import APIRouter, Depends, status, HTTPException, Response
from fastapi.responses import JSONResponse
from auth_bearer import JWTBearer,Role
import data.deepLearningRepository as repository
from data.data import  DeepLearning
router = APIRouter(tags=['Predict'])

# @router.get('/test',dependencies=[Depends(JWTBearer(role = Role.Admin))] )
@router.get('/DeepLearning/GetAll')
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
@router.get('/DeepLearning/GetByID')
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
@router.post('/DeepLearning/Create')
def Create(DeepName):
    result =repository.Create(DeepName)
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
@router.put('/DeepLearning/Update')
def Update(data: DeepLearning):
    result =repository.Update(data.DeepID,data.DeepName)
    if result is False:
        res = {
            "isSuccess": False,
            "Message": "Update error"
        }
        return JSONResponse(res)
    res = {
            "isSuccess": True,
            "Message": "Update Success"
        }
    return JSONResponse(res)
@router.delete('/DeepLearning/Delete')
def Delete(MachineID:str):
    result =repository.Delete(MachineID)
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