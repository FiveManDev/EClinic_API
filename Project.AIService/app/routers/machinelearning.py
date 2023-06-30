import sys
import os
data_path = os.path.join(os.path.dirname(__file__), '..', 'auth')
sys.path.append(data_path)
from fastapi import APIRouter, Depends, status, HTTPException, Response
from fastapi.responses import JSONResponse
from auth_bearer import JWTBearer,Role
import data.machineLearningRepository as repository
from data.data import MachineLearning
router = APIRouter(tags=['MachineLearning'])

# @router.get('/test',dependencies=[Depends(JWTBearer(role = Role.Admin))] )
@router.get('/MachineLearning/GetAll')
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
@router.get('/MachineLearning/GetByID')
async def GetByID(MachineID:str):
    try:
        data = repository.GetByID(MachineID)
        if data is None:
           res = {
            "isSuccess": False,
            "Message": "Not Found"
            }
        else:
            res = {
            "isSuccess": True,
            "data": data
            }
        return JSONResponse(res)
    except Exception as e:
        raise HTTPException(status_code=500, detail="Internal Server Error")          
@router.post('/MachineLearning/Create')
def Create(MachineName):
    result =repository.Create(MachineName)
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
@router.put('/MachineLearning/Update')
def Update(data:MachineLearning):
    result =repository.Update(data.MachineID,data.MachineName)
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
@router.delete('/MachineLearning/Delete')
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