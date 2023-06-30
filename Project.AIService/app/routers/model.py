import sys
import os
import shutil
data_path = os.path.join(os.path.dirname(__file__), '..', 'auth')
sys.path.append(data_path)
from fastapi import APIRouter, Depends, status, HTTPException, Response, File, UploadFile, Form
from fastapi.responses import JSONResponse
from auth_bearer import JWTBearer,Role
import data.modelRepository as repository
from data.data import ModelDtos
router = APIRouter(tags=['Model'])

# @router.get('/test',dependencies=[Depends(JWTBearer(role = Role.Admin))] )
@router.get('/Model/GetAll')
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
@router.get('/Model/GetByID')
async def GetByID(ModelID:str):
    try:
        data = repository.GetByID(ModelID)
        res = {
            "isSuccess": True,
            "data": data
        }
        return JSONResponse(res)
    except Exception as e:
        raise HTTPException(status_code=500, detail="Internal Server Error")          
@router.post('/Model/Create')
def Create(Accuracy:float= Form(...),MachineID:str= Form(...),DeepID:str= Form(...),file: UploadFile = File(...) ):
    FileUrl = 'model/' + file.filename
    save_path = os.path.join(os.getcwd(), FileUrl)

    with open(save_path, 'wb') as buffer:
        shutil.copyfileobj(file.file, buffer)
    result =repository.Create(Accuracy,MachineID,DeepID,FileUrl)
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
    return False
@router.put('/Model/Update')
def Update(ModelID:str=Form(...), Accuracy:float= Form(...),MachineID:str= Form(...),DeepID:str= Form(...),file: UploadFile = File(default=None) ):
    if file is not None:
        FileUrl = 'model/' + file.filename
        save_path = os.path.join(os.getcwd(), FileUrl)

        with open(save_path, 'wb') as buffer:
            shutil.copyfileobj(file.file, buffer)
    else:
        FileUrl =None
    result =repository.Update(ModelID,Accuracy,MachineID,DeepID,FileUrl)
    if result is False:
        res = {
            "isSuccess": False,
            "Message": "Update error"
        }
    else:
        res = {
            "isSuccess": True,
            "Message": "Update Success"
        }
    return JSONResponse(res)
@router.put('/Model/Active')
def Active(ModelID):
    result =repository.ActiveModel(ModelID)
    if result is False:
        res = {
            "isSuccess": False,
            "Message": "Update error"
        }
        return JSONResponse(res)
    else:
        res = {
            "isSuccess": True,
            "Message": "Update Success"
        }
    return JSONResponse(res)
@router.delete('/Model/Delete')
def Delete(ModelID:str):
    result =repository.Delete(ModelID)
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